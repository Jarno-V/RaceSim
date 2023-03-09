using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ControllerTest
{
    [TestFixture]
    public class Model_Competition_NextTrackShould
    {
        private Competition _competition;

        [SetUp]
        public void SetUp()
        {
            _competition = new Competition();
        }

        [Test]
        public void NextTrack_EmptyQueue_ReturnNull()
        {
            Track result = _competition.NextTrack();
            Assert.IsNull(result);
        }

        [Test]
        public void NextTrack_OneInQueue_ReturnTrack()
        {
            SectionTypes[] sections = new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.RightCorner };
            Track testTrack = new Track("Test", sections);
            _competition.Tracks.Enqueue(testTrack);

            Track result = _competition.NextTrack();
            Assert.AreEqual(testTrack, result);
        }

        [Test]
        public void NextTrack_OneInQueue_RemoveTrackFromQueue()
        {
            SectionTypes[] sections = new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.RightCorner };
            Track testTrack = new Track("Test2", sections);
            _competition.Tracks.Enqueue(testTrack);

            Track result = _competition.NextTrack();
            result = _competition.NextTrack();

            Assert.IsNull(result);
        }

        [Test]
        public void NextTrack_TwoInQueue_ReturnNextTrack()
        {
            SectionTypes[] sections = new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.RightCorner };
            Track testTrack1 = new Track("Test1", sections);
            Track testTrack2 = new Track("Test2", sections);
            _competition.Tracks.Enqueue(testTrack1);
            _competition.Tracks.Enqueue(testTrack2);

            Track result = _competition.NextTrack();
            Track result2 = _competition.NextTrack();

            Assert.AreEqual(result, testTrack1);
            Assert.AreEqual(result2, testTrack2);
        }

    }
}
