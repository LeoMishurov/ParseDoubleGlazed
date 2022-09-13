using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseDoubleGlazed
{
    public class DoubleGlazedParser
    {
        /// <summary>
        /// Преобразует строковое представление формулы стеклопакета в параметры стеклопакета. Возвращает значение, указывающее, успешно ли выполнена операция.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="glazedParams"></param>
        /// <returns></returns>
        public bool TryParse(string value, out DoubleGlazedParams? glazedParams)
        {
            glazedParams = null;
            // Массив с элементами строки разделенной по разделителю "/"
            string[] glass = value.Split(Constants.Delimiter);
            
            var result = new DoubleGlazedParams();
            // Определение камерности СП
            if (glass.Length == 5)
                result.Cameras = 2;
            else if (glass.Length == 3)
                result.Cameras = 1;
            else
                return false;
            
            //var spl1 = Glass.Select(x => new string(x.TakeWhile(c => char.IsDigit(c)).ToArray())).ToList();

            // Достаем число из каждого элемента строки
            for (int i = 0; i < glass.Length; i++) 
            {
                string spl = glass[i];

                string intStr;
                // Определяем колличество знаков в числе "согласно тз"
                if (spl.Length >= 1 && char.IsDigit(spl[0]))
                {
                    // Определяем колличество знаков в числе "согласно тз"
                    if (spl.Length >= 2 && char.IsDigit(spl[1]))
                    {
                        intStr = spl.Substring(0, 2);
                    }
                    else
                    {
                        intStr = spl.Substring(0, 1);
                    }
                }
                else
                    return false;
                // Парсим строку в число
                int val = int.Parse(intStr);
                // Определяем является ли параметр толщиной стекла
                if (i % 2 == 0)
                {
                    result.GlassThickness += val;
                }
                result.Thickness += val;
            }
            // Запись успешного результата
            glazedParams = result;
            return true;
        }
    }
}
