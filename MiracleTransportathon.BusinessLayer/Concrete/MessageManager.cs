﻿using MiracleTransportathon.BusinessLayer.Abstract;
using MiracleTransportathon.DataAccesLayer.Abstract;
using MiracleTransportathon.EntityLayer.Concrete;

namespace MiracleTransportathon.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(Message entity)
        {
            _messageDal.Add(entity);
        }

        public void TDelete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public List<Message> TGetAll()
        {
            return _messageDal.GetAll();
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
