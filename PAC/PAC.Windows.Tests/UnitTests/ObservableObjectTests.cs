
namespace PAC.Windows.Tests.UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObservableObjectTests
    {
        [TestMethod]
        public void PropertyChangedEventHandlerIsRaised()
        {
            var obj = new StubObservableObject();

            bool raised = false;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.IsTrue(e.PropertyName == "ChangedProperty");
                raised = true;
            };

            obj.ChangedProperty = "Some Value";

            if (!raised) Assert.Fail("PropertyChanged was never invoked.");
        }

        private class StubObservableObject : ObservableObject
        {
            private string _changedProperty;

            public string ChangedProperty
            {
                get { return _changedProperty; }
                set
                {
                    _changedProperty = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}