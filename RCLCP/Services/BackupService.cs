using RCLCP.Interfaces;
using System.Text.Json;


namespace RCLCP.Services
{
    public class BackupService : IBackup
    {
        public bool MakeBackup()
        {
            return true;
        }

        public bool ReadFile()
        {
            try
            {

                string filePath = "c:/temp/config1.json"; // Caminho do seu arquivo JSON

                // Lê o conteúdo do arquivo JSON
                string jsonContent = File.ReadAllText(filePath);

                // Desserializa o JSON em um objeto (por exemplo, uma lista de itens)
                var items = JsonSerializer.Deserialize<List<Item>>(jsonContent);

                items ??= [new() { Realizado = false }];

                // Agora você pode trabalhar com os dados (por exemplo, acessar propriedades dos itens)
                foreach (var item in items)
                {
                    Console.WriteLine($"Realizado: {item.Realizado}, Data: {item.Data}");
                }
            }
            catch (Exception)
            {

                throw;
            }
           

            return true;
        }

        public class Item
        {
            public bool Realizado { get; set; }
            public DateTime Data { get; set; }
        }

        public bool WriteFile()
        {
            var items = new List<Item>
            {
                new() { Realizado = true, Data = new DateTime(2024,06,19) }
            };

            string jsonContent = JsonSerializer.Serialize(items);

            string filePath = "c:/temp/config1.json"; 
            File.WriteAllText(filePath, jsonContent);

            Console.WriteLine($"Dados gravados em {filePath}");

            return true;
        }
    }
}
