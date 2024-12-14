using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BL
{
    public class RoleBL
    {
        private string xmlRole = "E:\\code\\vis\\code\\VIS_Project\\DL\\Role.xml";
        public RoleBL() { }

        public List<RoleDTO> LoadRoles()
        {
            XDocument doc = XDocument.Load(xmlRole);
            var roles = new List<RoleDTO>();

            foreach (var role in doc.Descendants("Role"))
            {
                var roleIdElement = role.Element("RoleId");
                var roleNameElement = role.Element("RoleName");

                if (roleIdElement != null && roleNameElement != null)
                {
                    roles.Add(new RoleDTO
                    {
                        id = int.Parse(roleIdElement.Value),
                        name = roleNameElement.Value
                    });
                }
            }

            return roles;
        }

        public string GetRoleNameByRoleId(int roleId)
        {
            var roles = LoadRoles();
            foreach (var role in roles)
            {
                if (role.id == roleId)
                {
                    return role.name;
                }
            }

            return "";
        }

        public int GetRoleIdByRoleName(string roleName)
        {
            var roles = LoadRoles();
            foreach (var role in roles)
            {
                if (role.name.ToLower() == roleName.ToLower())
                {
                    return role.id;
                }
            }
            return 0;
        }


    }
}
