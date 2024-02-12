using Business.DTOs;
using Core.Ultilities.Responses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IRoleService
    {
        Task<IResponse> AddRole(RoleDTO model);
        Task<IResponse> UpdateRole(RoleDTO model);
        Task<IResponse> RemoveRole(string id);
        Task<IResponse> GetRole(string id);
        IResponse GetRoles();
        Task<IResponse> GetAssignedRoles(string userid);
        Task<IResponse> RoleAssign(List<AssignRoleDTO> models);
    }
}
