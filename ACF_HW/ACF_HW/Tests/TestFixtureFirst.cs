using ACF_HW.Pages;
using Atata;
using COE.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACF_HW.Tests
{
    [TestFixture]
    class TestFixtureFirst : UITestFixtureBase
    {
        [Description("1. check that the following sections exist: " +
            "\"Погода у Харкові на два тижні\", \"Середньодобова температура\"," +
            "\"Вітер, м/с\", \"Тиск, мм рт.ст.\", \"Відносна вологість, %\"," +
            "\"Геомагнітна активність, Кp-індекс\",\"Погода на карті Європи\"" +
            "2. check that section \"Погода на карті Європи\" contains 4 subsections:" +
            "\"Опади\", \"Температура\", \"Вітер\", \"Хмарність\"")]
        [Test]
        public void Task1()
        {
            var page = Go.To<TwoWeeksPage>()
            .Forecast.Should.ExistSoft()
            .AverageTemp.Should.ExistSoft()
            .Wind.Should.ExistSoft()
            .Pressure.Should.ExistSoft()
            .Humidity.Should.ExistSoft()
            .GeomagneticActivity.Should.ExistSoft()
            .EuroMap.Should.ExistSoft()
            .EuroMapControlList.Count.Should.Equal(4)
            .EuroMapControlList[x => x.Title.Content == "Опади"].ScrollTo().Should.ExistSoft()
            .EuroMapControlList[x => x.Title.Content == "Температура"].ScrollTo().Should.ExistSoft()
            .EuroMapControlList[x => x.Title.Content == "Вітер"].ScrollTo().Should.ExistSoft()
            .EuroMapControlList[x => x.Title.Content == "Хмарність"].ScrollTo().Should.ExistSoft();
            page.ThrowSoftAsserts();
        }

        [Description("задание №2" +
            "Using waits" +
            "Using different types of waitings(attribute, or.Should.Within(40)) " +
            "on the page https://www.gismeteo.ua/ua/maps/eur/temp/ " +
            "click play button and check that datetime items " +
            "becoming blue(active) in order from top to bottom one by one.")]
        [Test]
        public void Task2()
        {
            var page = Go.To<TemperaturePage>()
            .RunPlayHistory()
            .CheckItemsBecomingActiveFromTopToBottom();
        }

        [Test]
        [Description("On the page https://www.gismeteo.ua/ua/maps/eur/temp/ create " +
            "custom component (class in your project) for dropdown list " +
            "for selecting timezone in top right corner with method 'Set' " +
            "wich will click on the select and select specified value. " +
            "Then write test that will use this component and check that " +
            "it works correctly.")]
        public void Task3()
        {
            var page = Go.To<TemperaturePage>();
            for (int i = -12; i <= 12; i++)
            {
                string index = i.ToString();
                page.TimeZone.Set(index);
                page.TimeZone.Should.Contain(index);
            }
        }
    }
}
