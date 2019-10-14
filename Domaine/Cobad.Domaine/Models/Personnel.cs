using System;
using System.Collections.Generic;
using System.Text;

namespace Cobad.Domaine
{
    public class Personnel
    {
        public Personnel(Role roleInClub, string nom, string tel, string mobile, string mail)
        {
            RoleInClub = roleInClub;
            Nom = nom;
            Tel = tel;
            Mobile = mobile;
            Mail = mail;
        }

        public enum Role
        {
            Dirigeant,
            Encadrant
        }

        public Role RoleInClub { get; set; }
        public string Nom { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Mail { get; set; }

    }
}
