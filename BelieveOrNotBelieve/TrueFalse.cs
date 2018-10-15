using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace BelieveOrNotBelieve
{
    class TrueFalse
    {
        string fileName;
        List<Question> list;
        public string FileName
        {
            set { fileName = value; }
        }
        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }
        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }
        // Индексатор - свойство для доступа к закрытому объекту
        public Question this[int index]
        {
            get { return list[index]; }
        }
        public void Save()
        {

            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
                       
        }
        /// <summary>
        /// Метод для записи файла  в формате Json (Получилась кривая структура файла но почемуто работает)
        /// </summary>
        public void SaveJson()
        {

             System.IO.File.WriteAllText(fileName, JsonConvert.SerializeObject(list));
        }
        public void Load()
        {
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
                Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                list = (List<Question>)xmlFormat.Deserialize(fStream);
                fStream.Close();

            }
            catch (System.InvalidOperationException)
            {
                new MessageDialog("Невозможно прочитать файл " + fileName).ShowAsync();


            } 
            
            
            
        }

       

        /// <summary>
        /// кривая структура файла но подгружается
        /// </summary>
        public void LoadJson()
        {
            
            string jsonFormat = System.IO.File.ReadAllText(fileName);
            list = JsonConvert.DeserializeObject<List<Question>>(jsonFormat);

        }
        public int Count
        {
            get { return list.Count; }
        }
    }

}
    
