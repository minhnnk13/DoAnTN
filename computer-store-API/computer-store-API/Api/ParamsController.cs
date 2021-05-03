using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace computer_store_API.Api
{
    public class ParamsController:EntityController<Param>
    {
        public IActionResult InsertFee(Param param)
        {
            return Insert(param);
        }

        public IActionResult UpdateFee(Param param, int id)
        {
            return Update(param, id);
        }
    }
}
