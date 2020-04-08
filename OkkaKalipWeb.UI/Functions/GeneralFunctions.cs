﻿using System;

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
    }
}