using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FootballMatches.Web.Models
{
    public class PlayerModel
    {               
        public int Id { get; set; }
        
        public string Name { get; set; }

    }
}
