using SQLite.Net;
using SqliteApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Storage;

namespace SqliteApp.Services
{
    public class TileService
    {
        public static XmlDocument CreateTile(int productID)
        {
            
            Product prod;
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path,
         "Products.sqlite");
            using (var conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(),
                path))
            {
                prod = conn.Table<Product>().FirstOrDefault(p => p.Id == productID);
            }

            var tileXML = new XmlDocument();
            var tileXMLText = String.Format(
                @"<?xml version='1.0' encoding='utf-8'?>
                    <tile><visual displayName='{0}' baseUri='Assets/'>", prod.Name);

            // Small Tile 
            tileXMLText += String.Format(
               @"<binding template='TileSmall' hint-textStacking='center' hint-overlay='30'>
                    <image src='avatar.png' placement='background' />
                    <text hint-style='body' hint-align='center'>{0}</text>
                    <text hint-style='base' hint-align='center'>{1}</text>
                </binding>", prod.Name, prod.Price);

            // Medium Tile
            tileXMLText += String.Format(
                @"<binding template='TileMedium' branding='name' hint-overlay='30' >
                  <image src='avatar.png' placement='background' />
                    <text hint-style='body' hint-align='center'>Распродажа!</text>
                    <text hint-style='base' hint-align='center'>{1}</text>
                    <text hint-style='base' hint-align='center'>{2}</text>
                </binding>", prod.Name, prod.Price, prod.Description);

            // Wide Tile
            tileXMLText += String.Format(
                 @"<binding template='TileWide' branding='name' hint-overlay='30' >
                  <image src='avatar.png' placement='background' />
                    <text hint-style='body' hint-align='center'>Распродажа!</text>
                    <text hint-style='base' hint-align='center'>{1}</text>
                    <text hint-style='base' hint-align='center'>{2}</text>
                </binding>", prod.Name, prod.Price, prod.Description);


            // end
            tileXMLText += " </visual ></tile >";

            tileXML.LoadXml(tileXMLText);

            return tileXML;
        }

    }
}
