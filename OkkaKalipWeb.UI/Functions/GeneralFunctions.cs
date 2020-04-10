using System;
using System.Collections.Generic;
using System.Linq;

namespace OkkaKalipWeb.UI.Functions
{
    public static class GeneralFunctions
    {
        public static string ChangeMapUrl(this string mapUrl)
        {
            var mapSplit = mapUrl.Split(' ');
            string reMapUrl = "";

            mapSplit[2] = "width='1170'";
            mapSplit[3] = "height='500'";

            foreach (var item in mapSplit)
            {
                reMapUrl += item + " ";
            }

            return reMapUrl.Replace('"', Convert.ToChar("'"));
        }

        public static string ToSubstring(this string text, int lenght = 100)
        {
            return text.Length > lenght ? text.Substring(0, lenght).Trim('\n') : text;
        }

        public static T GetRandomEntity<T>(this List<T> entities) where T : class
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var r = new Random();
            var list = entities as IList<T> ?? entities.ToList();
            return list.Count == 0 ? default : list[r.Next(0, list.Count)];
        }
    }
}