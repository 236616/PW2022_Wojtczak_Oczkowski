using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Data
{
    public class Logger
    {
        private string filePath;
        private DataAPI ball;
        private readonly JArray fileDataArray = new JArray();

        public Logger(DataAPI _ball)

        {
            ball = _ball;
            string tempPath = Path.GetTempPath();
            filePath = tempPath + "LOGS\\ball" + ball.id + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".json";
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (IOException e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            //File.Create(filePath);
        }

        public async void log()
        {

            fileDataArray.Add(JObject.FromObject(ball));
            string output = JsonConvert.SerializeObject(fileDataArray, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }
    }
}
