using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreSliderDal : EfCoreRepository<Slider, NakisKalipContext>, ISliderDal
    {
    }
}
