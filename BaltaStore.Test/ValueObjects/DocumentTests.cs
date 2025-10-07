
using Document = BaltaStore.Domain.StoreContext.ValueObjects.Document;

namespace BaltaStore.Test.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document invalidDocument;
        private Document validDocument;

        public DocumentTests()
        {
            invalidDocument = new Document("123789456710");
            validDocument = new Document("66191947100");
        }
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, invalidDocument.IsValid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }

         [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }

    }
}