using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{
    public class PointService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PointService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Point> GetAll()
        {
            return _unitOfWork.Points.GetAll().ToList();
        }

        public Point GetById(long id)
        {
            return _unitOfWork.Points.GetById(id);
        }

        public Point Add(Point point)
        {
            _unitOfWork.Points.Add(point);
            _unitOfWork.Complete();
            return point;
        }

        public bool Update(long id, Point updatedPoint)
        {
            var existingPoint = _unitOfWork.Points.GetById(id);
            if (existingPoint == null)
            {
                return false;
            }

            existingPoint.PointX = updatedPoint.PointX;
            existingPoint.PointY = updatedPoint.PointY;
            existingPoint.Name = updatedPoint.Name;

            _unitOfWork.Points.Update(existingPoint);
            _unitOfWork.Complete();

            return true;
        }

        public bool Delete(long id)
        {
            var point = _unitOfWork.Points.GetById(id);
            if (point == null)
            {
                return false;
            }

            _unitOfWork.Points.Delete(point);
            _unitOfWork.Complete();
            return true;
        }
    }
}
