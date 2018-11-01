using System;
using System.ServiceModel;

namespace PropertyRentalSystemService
{    
    [ServiceContract]
    public interface IPropertyRentalSystemService
    {
        [OperationContract]
        bool setAddress(string address);
        [OperationContract]
        string getAddress();
        [OperationContract]
        bool setPostalCode(string postalCode);
        [OperationContract]
        string getPostalCode();
        [OperationContract]
        bool setCurrentStatus(bool status);
        [OperationContract]
        bool getCurrentStatus();
        [OperationContract]
        bool setLeaseEndDate(string date);
        [OperationContract]
        string getLeaseEndDate();
        [OperationContract]
        bool setStudentsAllowed(bool studentsAllowed);
        [OperationContract]
        bool getStudentsAllowed();
        [OperationContract]
        bool setMultipleOccupantsAllowed(bool multipleOccupantsAllowed);
        [OperationContract]
        bool getMultpleOccupantsAllowed();
        [OperationContract]
        bool setNoOfOccupantsAllowed(int noOfOccupantsAllowed);
        [OperationContract]
        int getNoOfOccupantsAllowed();
        [OperationContract]
        bool setPetsAllowed(bool petsAllowed);
        [OperationContract]
        bool getPetsAllowed();
        [OperationContract]
        bool setChildrenAllowed(bool childrenAllowed);
        [OperationContract]
        bool getChildrenAllowed();
        [OperationContract]
        Boolean insertIntoTable();
        [OperationContract]
        string selectFromTableUsingPostalCode();
        [OperationContract]
        string selectFromTableForAvailableProperty();       
    }
}
