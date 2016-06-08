using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebHzg.Entities;
using MyWebHzg.BaseRepositories;

namespace MyWebHzg.Repositories
{

    public partial class MediumTypeRepository : GenericRepository<MediumType, MovieContext>, IMediumTypeRepository
   {

   }

}