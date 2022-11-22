using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GroupServices
    {
        public static List<GroupDTO> Get()
        {
            var data = DataAccessFectory.GroupDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>());
            var mapper = new Mapper(config); 
            var rtdata = mapper.Map<List<GroupDTO>>(data);
            return rtdata;

        }

        public static GroupDTO Get(int Id)
        {
            var data = DataAccessFectory.GroupDataAccess().Get(Id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>());
            var mapper = new Mapper(config);
            var rtdata = mapper.Map<GroupDTO>(data);
            return rtdata;

        }

        public static bool Add(GroupDTO obj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, Group>());
            var mapper = new Mapper(config);
            var rtdata = mapper.Map<Group>(obj);
            return DataAccessFectory.GroupDataAccess().Add(rtdata);
        }

        public static bool Update(GroupDTO obj)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, Group>());
            var mapper = new Mapper(config);
            var rtdata = mapper.Map<Group>(obj);
            return DataAccessFectory.GroupDataAccess().Update(rtdata);
        }

        public static bool Delete(int id)
        {
            return DataAccessFectory.GroupDataAccess().Delete(id);
        }



    }
}
