﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UWPEindopdracht.GPSConnections;
using UWPEindopdracht.Places;

namespace UWPEindopdracht.JSON
{
    class GooglePlacesParser
    {
        public static string GetStatus(string response)
        {
            dynamic json = JsonConvert.DeserializeObject(response);
            string token = json.status;
            if (token == "" || token == " ")
                return null;
            return token;
        }
        public static string NextPage(string response)
        {
            dynamic json = JsonConvert.DeserializeObject(response);
            string token = json.next_page_token;
            if (token == "" || token == " ")
                return null;
            return token;
            
        }
        public static List<Place> GetPlaces(string response)
        {
            dynamic json = JsonConvert.DeserializeObject(response);
            var placesToSend = new List<Place>();
            
            
            if (!(json is JObject))
            {
                return null;
            }
            foreach (dynamic jsonplace in json.results)
            {
                var typeList = new List<string>();
                foreach (var type in jsonplace.types)
                {
                    typeList.Add((string)type);
                }
                
                var place = new Place
                {
                    PlaceId = (string)jsonplace.id,
                    Location = new GCoordinate((double)jsonplace.geometry.location.lat, 
                                                (double)jsonplace.geometry.location.lng),
                    Name = (string)jsonplace.name,
                    Types = typeList.ToArray(),
                    IconLink = jsonplace.icon,
                    ImageLocation = jsonplace.reference
                };
                if (jsonplace.geometry.viewport != null)
                {
                    var viewports = (JObject) jsonplace.geometry.viewport;
                    place.Viewports = new GCoordinate[viewports.Count];
                    int index = 0;
                    foreach (var viewport in viewports)
                    {
                        place.Viewports[index] = new GCoordinate((double)((dynamic)viewport.Value).lat, (double)((dynamic)viewport.Value).lng);
                        index++;
                    }
                }
                placesToSend.Add(place);
            }
            return placesToSend;
        }
    }
}
