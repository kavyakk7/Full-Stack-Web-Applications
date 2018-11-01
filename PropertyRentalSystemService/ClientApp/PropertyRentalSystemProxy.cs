using PropertyRentalService;
using System;
using System.ServiceModel;

namespace ClientApp
{
    class PropertyRentalSystemProxy: ClientBase<IPropertyRentalService> , IPropertyRentalService
    {
        public bool setAddress(string address)
        {
            return base.Channel.setAddress(address);
        }
        public string getAddress()
        {
            return base.Channel.getAddress();
        }
        public bool setPostalCode(string postalCode)
        {
            return base.Channel.setPostalCode(postalCode);
        }
        public string getPostalCode()
        {
            return base.Channel.getPostalCode();
        }
        public bool setCurrentStatus(bool status)
        {
            return base.Channel.setCurrentStatus(status);
        }
        public bool getCurrentStatus()
        {
            return base.Channel.getCurrentStatus();
        }
        public bool setLeaseEndDate(string date)
        {
            return base.Channel.setLeaseEndDate(date);
        }
        public string getLeaseEndDate()
        {
            return base.Channel.getLeaseEndDate();
        }
        public bool setStudentsAllowed(bool studentsAllowed)
        {
            return base.Channel.setStudentsAllowed(studentsAllowed);
        }
        public bool getStudentsAllowed()
        {
            return base.Channel.getStudentsAllowed();
        }
        public bool setMultipleOccupantsAllowed(bool multipleOccupantsAllowed)
        {
            return base.Channel.setMultipleOccupantsAllowed(multipleOccupantsAllowed);
        }
        public bool getMultpleOccupantsAllowed()
        {
            return base.Channel.getMultpleOccupantsAllowed();
        }
        public bool setNoOfOccupantsAllowed(int noOfOccupantsAllowed)
        {
            return base.Channel.setNoOfOccupantsAllowed(noOfOccupantsAllowed);
        }
        public int getNoOfOccupantsAllowed()
        {
            return base.Channel.getNoOfOccupantsAllowed();
        }
        public bool setPetsAllowed(bool petsAllowed)
        {
            return base.Channel.setPetsAllowed(petsAllowed);
        }
        public bool getPetsAllowed()
        {
            return base.Channel.getPetsAllowed();
        }
        public bool setChildrenAllowed(bool childrenAllowed)
        {
            return base.Channel.setChildrenAllowed(childrenAllowed);
        }
        public bool getChildrenAllowed()
        {
            return base.Channel.getChildrenAllowed();
        }
        public Boolean insertIntoTable()
        {
            return base.Channel.insertIntoTable();
        }
        public string selectFromTableUsingPostalCode()
        {
            return base.Channel.selectFromTableUsingPostalCode();
        }
        public string selectFromTableForAvailableProperty()
        {
            return base.Channel.selectFromTableForAvailableProperty();
        }
    }
 }
