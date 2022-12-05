using Moq;
using NUnit.Framework;
using RushCodingAssignment;
using RushCodingAssignment.Business;
using RushCodingAssignment.Business.Interfaces;
using RushCodingAssignment.Data.Interfaces;
using RushCodingAssignment.Models;
using RushCodingAssignment.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace UnitTests
{
	public class Tests
	{
		private IEnumerable<PhotoAlbumModel> _albums;
		[SetUp]
		public void Setup()
		{
			_albums = new List<PhotoAlbumModel>
			{
				new PhotoAlbumModel { AlbumId = 1, Id = 1, ThumbnailUrl = "testThumbnail", Url = "testUrl", Title = "testTitle" }
			};
		}

		[Test]
		public void Service_HappyPath()
		{
			IEnumerable<PhotoAlbumModel> result = new List<PhotoAlbumModel>
			{
				new PhotoAlbumModel { AlbumId = 1, Id = 1, ThumbnailUrl = "testThumbnail", Url = "testUrl", Title = "testTitle" }
			};
			Mock<IContainer> mockContainer = new Mock<IContainer>();
			Mock<IPhotoAlbumBusiness> mockBusiness = new Mock<IPhotoAlbumBusiness>();
			mockBusiness.Setup(x => x.GetAsync(1))
						.ReturnsAsync(result);
			Mock<IFileLogger> mockLogger =new Mock<IFileLogger>();

			var service = new PhotoAlbumService(mockBusiness.Object, mockLogger.Object);
			var response = service.GetAsync(1).Result;

			Assert.IsNotNull(response);
			Assert.AreEqual(response.Count(), _albums.Count());
			var _albumObj = _albums.ToList()[0];
			var responseObj = response.ToList()[0];
			Assert.AreEqual(responseObj.AlbumId, _albumObj.AlbumId);
			Assert.AreEqual(responseObj.Id, _albumObj.Id);
			Assert.AreEqual(responseObj.ThumbnailUrl, _albumObj.ThumbnailUrl);
			Assert.AreEqual(responseObj.Url, _albumObj.Url);
		}

		[Test]
		public void Business_HappyPath()
		{
			IEnumerable<PhotoAlbumModel> result = new List<PhotoAlbumModel>
			{
				new PhotoAlbumModel { AlbumId = 1, Id = 1, ThumbnailUrl = "testThumbnail", Url = "testUrl", Title = "testTitle" }
			};
			Mock<IContainer> mockContainer = new Mock<IContainer>();
			Mock<IPhotoAlbumData> mockData = new Mock<IPhotoAlbumData>();
			mockData.Setup(x => x.GetAsync(1))
						.ReturnsAsync(result);
			Mock<IFileLogger> mockLogger = new Mock<IFileLogger>();

			var business = new PhotoAlbumBusiness(mockData.Object, mockLogger.Object);
			var response = business.GetAsync(1).Result;

			Assert.IsNotNull(response);
			Assert.AreEqual(response.Count(), _albums.Count());
			var _albumObj = _albums.ToList()[0];
			var responseObj = response.ToList()[0];
			Assert.AreEqual(responseObj.AlbumId, _albumObj.AlbumId);
			Assert.AreEqual(responseObj.Id, _albumObj.Id);
			Assert.AreEqual(responseObj.ThumbnailUrl, _albumObj.ThumbnailUrl);
			Assert.AreEqual(responseObj.Url, _albumObj.Url);
		}

		[Test]
		public void Business_NegativeAlbumId()
		{
			Mock<IContainer> mockContainer = new Mock<IContainer>();
			Mock<IPhotoAlbumData> mockData = new Mock<IPhotoAlbumData>();
			Mock<IFileLogger> mockLogger = new Mock<IFileLogger>();

			var business = new PhotoAlbumBusiness(mockData.Object, mockLogger.Object);

			Assert.Throws<AggregateException>(() =>
			{
				var result = business.GetAsync(-1).Result;
			});
		}

	}
}