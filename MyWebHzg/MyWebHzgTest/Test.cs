using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebHzg.Service;

namespace MyWebHzg.MyWebHzgTest
{
    [TestFixture]
    public class Test
    {

        private  HzgWebService wks;

        public Test()
        {
            this.wks = new HzgWebService();
        }


        //[Test]
        //public void GetAllAddresses()
        //{
        //    var addresses = this.wks.GetAllAddresses();
        //    Assert.NotNull(addresses);
                       
        //}

        //[Test]
        //public void GetAddressesByLastName()
        //{
        //    var addresses = this.wks.GetAddressesByLastname("Leonard");
        //    Assert.NotNull(addresses);
        //    Assert.AreEqual(addresses[0].Lastname, "Leonard Garet");
        //}
    }



}
