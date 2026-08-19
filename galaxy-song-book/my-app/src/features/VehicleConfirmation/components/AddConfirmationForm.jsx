import React from 'react';
import InputField from "../../../components/InputField";
import SelectedBusinessPartnerBox from "../../BusinessPartners/select-bp";

const AddConfirmationForm = ({ formik, fields, id, handleDelete }) => {
  return (
    <form onSubmit={formik.handleSubmit} className="p-3">
      <div className="row">
        <div className="col-sm-6">
          <div className="card mb-3">
            <div className="card-header">Vehicle Photos</div>
            <div className="card-body">
              <div className="row">
                <InputField className="col-12 mb-2" {...fields.images} formik={formik} />
              </div>
            </div>
          </div>
        </div>

        <div className="col-sm-6">
          <div className="card mb-3">
            <div className="card-header">Vehicle Details</div>
            <div className="card-body">
              <div className="row">
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.make} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.model} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.grade} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.colour} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.fuelType} formik={formik} />

                <InputField className="col-md-3 col-sm-6 col-6" {...fields.transmission} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.year} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.millage} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.engineCapacity} formik={formik} />

                <InputField className="col-md-9 col-sm-6 col-6" {...fields.chassisNo} formik={formik} />
              </div>
            </div>
          </div>
        </div>

        <div className= "col-sm-12" >
          <div className="card mb-3">
            <div className="card-header">Description</div>
            <div className="card-body">
              <InputField className="col-12" {...fields.description} formik={formik} />
            </div>
          </div>
        </div>

        <div className="col-sm-12">
          <div className="card mb-3">
            <div className="card-header">Purchase Details</div>
            <div className="card-body">
              <div className="row">
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.purchaseDate} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.auctionPrice} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.cifYen} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.tax} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.freight} formik={formik} />
              </div>

              <div className="row">
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.paymentDate} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.paymentAmount} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.paymentRate} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.paymentAmountYen} formik={formik} />
              </div>

              <div className="row">
                <SelectedBusinessPartnerBox className="col-md-6 col-sm-12 " field={fields.supplier} formik={formik} />
                <InputField className="col-md-6 col-sm-12 " {...fields.paymentDetails} formik={formik} />
              </div>
            </div>
          </div>
        </div>

        <div className="col-sm-12">
          <div className="card mb-3">
            <div className="card-header">L.C.</div>
            <div className="card-body">
              <div className="row">
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.lcOpenDetailsDate} formik={formik} />
                <InputField className="col-md-6 col-sm-12 col-6" {...fields.lcOpenDetailsBank} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.JPY} formik={formik} />
              </div>
              <div className="row">
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.lcMarginDate} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.lcMarginAmount} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.lcSettlementAmount} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.lcSettlementCharges} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.lcSettlementDate} formik={formik} />
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="row">
        <div className="col-12">
          <div className="card mb-3">
            <div className="card-header">Clearance</div>
            <div className="card-body">
              <div className="row">
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.dutyDate} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.dutyAmount} formik={formik} />
              </div>
              <div className="row">
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.clearingDate} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.clearingCharges} formik={formik} />

                <InputField className="col-md-3 col-sm-6 col-6" {...fields.salesTax} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.transportCost} formik={formik} />
                <InputField className="col-md-3 col-sm-6 col-6" {...fields.totalCost} formik={formik} />
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="d-flex justify-content-end mt-3">
        {id && (
          <>
            <button type="button" className="btn btn-outline-danger me-2" onClick={() => handleDelete()}>Delete</button>
          </>
        )}
        <button type="submit" className="btn btn-primary">Save</button>
      </div>
    </form>
  );
};

export default AddConfirmationForm;
