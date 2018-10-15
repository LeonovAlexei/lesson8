//Леонов Алексей
//С помощью рефлексии выведите все свойства структуры DateTime
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L8T1
{
    class Program
    {
        static PropertyInfo GetPropertyInfo(object obj, string str)
        {
            return obj.GetType().GetProperty(str);
        }
        static void PtintPropertyInfo(DateTime date,string property)
        {
            Console.WriteLine($"Возможно ли считать свойство {property}-----> {GetPropertyInfo(date, property).CanRead}");
            Console.WriteLine($"Возможно ли производить запись в свойство {property}-----> {GetPropertyInfo(date, property).CanWrite}");
            Console.WriteLine($"Значение свойства {property}-----> {GetPropertyInfo(date, property).GetValue(date)}");
            Console.WriteLine(  );
        }

        static void Main(string[] args)
        {
            DateTime date = DateTime.Now;
                
            Console.WriteLine(date); 
           

            PtintPropertyInfo(date, "DayOfWeek");//Возвращает день недели
            PtintPropertyInfo(date, "Now");//Возвращает объект System.DateTime, которому присвоены 
                                           //текущие дата и время данного компьютера
            PtintPropertyInfo(date, "UtcNow");// Возвращает объект System.DateTime, которому 
                                              // присвоены текущие дата и время данного компьютера,
                                               //выраженные в формате UTC.
            PtintPropertyInfo(date, "Today");//Возвращает текущую дату.
            PtintPropertyInfo(date, "Ticks"); //Возвращает число тактов, которое представляет дату и время
            PtintPropertyInfo(date, "Date");//Возвращает компоненту даты
            PtintPropertyInfo(date, "Month");//Возвращает компонент месяца даты
            PtintPropertyInfo(date, "Minute");//Возвращает компонент минуты даты
            PtintPropertyInfo(date, "Millisecond");//Возвращает компонент миллисекунд для даты
            PtintPropertyInfo(date, "Kind");//Возвращает значение, указывающее, на каком времени основано время, представленное
                                            //этим экземпляром: местном, UTC или ни на том, ни на другом.
            PtintPropertyInfo(date, "Hour");//Возвращает компонент часа даты
            PtintPropertyInfo(date, "DayOfYear");//Возвращает день года
            PtintPropertyInfo(date, "Day");//Возвращает день месяца
            PtintPropertyInfo(date, "Second");//Возвращает компонент секунды даты
            PtintPropertyInfo(date, "TimeOfDay");//Возвращает время дня
            PtintPropertyInfo(date, "Year");//Возвращает компонент года даты



            Console.ReadLine();

        }
    }
}
