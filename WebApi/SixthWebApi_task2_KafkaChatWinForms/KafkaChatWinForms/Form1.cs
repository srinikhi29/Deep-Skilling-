using Confluent.Kafka;

namespace KafkaChatWinForms
{
    public partial class Form1 : Form
    {
        private IProducer<Null, string> _producer;
        private CancellationTokenSource _cts;

        public Form1()
        {
            InitializeComponent();
            StartKafka();
        }

        private void StartKafka()
        {
            var producerConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };
            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();

            _cts = new CancellationTokenSource();
            Task.Run(() => ConsumeLoop(_cts.Token));
        }

        private void ConsumeLoop(CancellationToken token)
        {
            var config = new ConsumerConfig
            {
                GroupId = Guid.NewGuid().ToString(), // unique per window so every window gets every message
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("chat-topic");

            try
            {
                while (!token.IsCancellationRequested)
                {
                    var cr = consumer.Consume(token);

                    if (lstChat.InvokeRequired)
                    {
                        lstChat.Invoke(() => lstChat.Items.Add(cr.Message.Value));
                    }
                    else
                    {
                        lstChat.Items.Add(cr.Message.Value);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // expected on form close
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text)) return;

            string username = string.IsNullOrWhiteSpace(txtUsername.Text) ? "Anonymous" : txtUsername.Text;
            string fullMessage = $"{username}: {txtMessage.Text}";

            try
            {
                await _producer.ProduceAsync("chat-topic",
                    new Message<Null, string> { Value = fullMessage });
            }
            catch (ProduceException<Null, string> ex)
            {
                MessageBox.Show($"Failed to send: {ex.Error.Reason}");
            }

            txtMessage.Clear();
            txtMessage.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cts?.Cancel();
            _producer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}