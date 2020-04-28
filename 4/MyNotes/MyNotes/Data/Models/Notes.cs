using System.Collections.Generic;
using System.Collections.Specialized;

namespace MyNotes.Data.Models
{
    public class Notes
    {
        public static bool operator ==(Notes first, Notes second) 
        {
            return Equals(first, second);
        }
        
        public static bool operator !=(Notes first, Notes second) 
        {
            // or !Equals(first, second), but we want to reuse the existing comparison 
            return !(first == second);
        }
        
        public string Note { get; set; }
    }
}