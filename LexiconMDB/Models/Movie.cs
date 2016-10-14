using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;

namespace LexiconMDB.Models
{
    public class Movie
    {
        [Key] //Not necessary
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Range(0,int.MaxValue, ErrorMessage ="Only positive")]
        public int Length { get; set; }
        public Genre Genre { get; set; }

        [Display(Name ="Age Limit")]
        [Range(0,100,ErrorMessage = "0-18")]
        public int AgeLimit { get; set; }

        [Range(0, 100, ErrorMessage = "0-100")]
        public int MetaScore { get; set; }
        public string LengthInHours {
            get
            {
                var hours = (Length / 60);
                var minutes = Length - hours * 60;
                return $"{hours}:{minutes:00}";
            }
        }

    }
    public enum Genre
    {
        Drama,
        Horror,
        Comedy,
       //[Display(Name = "Drama Comedy", ResourceType = typeof(Movie))]
        DramaComedy
    }

    public static class EnumExtensions
    {
        public static string GetDisplayAttributeFrom(this Enum enumValue, Type enumType)
        {
            string displayName = "";
            MemberInfo info = enumType.GetMember(enumValue.ToString()).First();

            if (info != null && info.CustomAttributes.Any())
            {
                DisplayAttribute nameAttr = info.GetCustomAttribute<DisplayAttribute>();

                if (nameAttr != null)
                {
                    // Check for localization
                    if (nameAttr.ResourceType != null && nameAttr.Name != null)
                    {
                        // I recommend not newing this up every time for performance
                        // but rather use a global instance or pass one in
                        var manager = new ResourceManager(nameAttr.ResourceType);
                        displayName = manager.GetString(nameAttr.Name);
                    }
                    else if (nameAttr.Name != null)
                    {
                        displayName = nameAttr != null ? nameAttr.Name : enumValue.ToString();
                    }
                }
            }
            else
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
}