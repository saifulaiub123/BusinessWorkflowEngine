﻿using BWE.Domain.Model;
namespace BWE.Domain.ViewModel
{
    public class ScriptViewModel : ScriptModel
    {
        public string DestinationServerName { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
