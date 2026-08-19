import React from "react";
import { useModalService } from "../../helpers/ModalService";
import BusinessPartnerFind from "./BusinessPartnerFind";
import ApiService from "./PartnerService";
import Tabs from "../../components/Tabs";
import AddBusinessPartner from "./AddBusinessPartner";

function SelectedBusinessPartnerBox({
  field,
  formik,
  className,
  selectedPartner,
  onContinue,
  onChangePartner,
  onCustomerSelect = () => {},
  setCustomerOption = () => {},
  required = false,
  ...props
}) {
  const [open, setOpen] = React.useState(formik.isOpen);
  const [localSelectedPartner, setLocalSelectedPartner] = React.useState(selectedPartner);
  const [activeTab, setActiveTab] = React.useState("search");
  const [tabsInitialized, setTabsInitialized] = React.useState(false);

  React.useEffect(() => {
    
    setLocalSelectedPartner(selectedPartner);
  }, [selectedPartner]);

  React.useEffect(() => {
    if (formik.values[field?.name]) {

      const fetchInquiries = async () => {
        try {
          const storedPartners = await ApiService.get(
            formik.values[field?.name]
          );
          setLocalSelectedPartner(storedPartners.data);
        } catch (error) {
          setLocalSelectedPartner(null);
        }
      };
      fetchInquiries();
    } else {
      setLocalSelectedPartner(null);
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [formik.values[field?.name]]);

  const { openModal, closeModal } = useModalService();

  const handleCustomerSelect = (customer) => {
    setLocalSelectedPartner(customer);
    closeModal();
    formik.setFieldValue(field?.name, customer.businessPartnerId || customer.id || "");
    if (onCustomerSelect) {
      onCustomerSelect(customer);
    }
    if (onChangePartner) {
      onChangePartner(customer);
    }
  };

  const handleNewCustomerClick = () => {
    setActiveTab("add-customer");
    if (!tabsInitialized) {
      setTabsInitialized(true);
    }
  };

  const handleCustomerCreated = (newCustomer) => {
    handleCustomerSelect(newCustomer);
    setActiveTab("search");
    closeModal();
  };

  // Show modal with current tab
  const showModal = (tabId = activeTab) => {
    openModal({
      title: tabId === "add-customer" ? "Add New Customer" : "Select Customer",
      component: (
        <Tabs tabs={tabs} activeTab={tabId} onTabChange={handleTabChange}>
          {tabId === "search" && (
            <>
              <BusinessPartnerFind
                onCustomerSelect={handleCustomerSelect}
                onNewCustomer={handleNewCustomerClick}
                type={field.type}
              />
            </>
          )}
          {tabId === "add-customer" && (
            <div className="mt-3">
              <AddBusinessPartner
                onCustomerCreated={handleCustomerCreated}
                noForm={true}
              />
            </div>
          )}
        </Tabs>
      ),
    });
  };

  const handleTabChange = (tabId) => {
    setActiveTab(tabId);
    showModal(tabId);
  };

  const tabs = [
    { id: "search", label: `Search ${field.placeholder}`, disabled: false },
    { id: "add-customer", label: `Add New ${field.placeholder}`, disabled: false },
  ];

  return (
    <div className={className || "col-sm-12"}>
      <label className="form-label">
        {field?.placeholder || "Customer"}
        {required && <span className="text-danger ms-1">*</span>}
      </label>
      <div className="accordion" id="selectedPartnerAccordion">
        <div className="accordion-item">
          <h2
            className="accordion-header d-flex align-items-center justify-content-between"
            id="selectedPartnerHeading"
          >
            <button
              className={`accordion-button bp-accordion-btn${open ? "" : " collapsed"}`}
              type="button"
              aria-expanded={open}
              aria-controls="selectedPartnerCollapse"
              onClick={() => setOpen((prev) => !prev)}
            >
              {localSelectedPartner?.isCustomer ? (
                <>
                  {" "}
                  <div
                    className="d-flex align-items-center justify-content-center bg-primary text-white bp-type-badge"
                    onClick={(e) => e.stopPropagation()}
                  >
                    C
                  </div>{" "}
                </>
              ) : null}
              {localSelectedPartner?.isSupplier ? (
                <>
                  {" "}
                  <div
                    className="d-flex align-items-center justify-content-center bg-primary text-white bp-type-badge"
                    onClick={(e) => e.stopPropagation()}
                  >
                    S
                  </div>{" "}
                </>
              ) : null}
              {localSelectedPartner?.isEmployee ? (
                <div
                  className="d-flex align-items-center justify-content-center bg-primary text-white bp-type-badge"
                  onClick={(e) => e.stopPropagation()}
                >
                  E
                </div>
              ) : null}
              <h6 className="mb-0">
                <small className="text-muted">
                  {localSelectedPartner?.partnerCode
                    ? ` ${localSelectedPartner.partnerCode} - `
                    : ""}
                </small>{" "}
                {localSelectedPartner?.partnerName ||
                  localSelectedPartner?.partnerCode ||
                  "-"}
              </h6>
            </button>
            <button
              className="btn btn-secondary ms-2"
              onClick={() => showModal()}
              type="button"
            >
              <i className="bi bi-search"></i>
            </button>
          </h2>
        </div>
        <div
          id="selectedPartnerCollapse"
          className={`accordion-collapse collapse${open ? " show" : ""}`}
          aria-labelledby="selectedPartnerHeading"
          data-bs-parent="#selectedPartnerAccordion"
        >
          <div className="accordion-body card">
            <div className="">
              <div className="row">
                <div className="col-md-6 mb-2">
                  <div>
                    <i className="bi bi-person-fill text-primary"></i>{" "}
                    {localSelectedPartner?.contactPerson || "-"}
                  </div>
                </div>

                <div className="col-md-6 mb-2">
                  <div>
                    <i className="bi bi-envelope-fill text-primary"></i>{" "}
                    {localSelectedPartner?.email ? (
                      <a
                        href={`mailto:${localSelectedPartner.email}`}
                        onClick={(e) => e.stopPropagation()}
                      >
                        {localSelectedPartner.email}
                      </a>
                    ) : (
                      "-"
                    )}
                  </div>
                </div>

                <div className="col-md-6 mb-2">
                  <div>
                    <i className="bi bi-geo-alt-fill text-primary"></i>{" "}
                    {localSelectedPartner?.address || "-"}
                  </div>
                </div>

                <div className="col-md-6 mb-2">
                  <div>
                    <i className="bi bi-telephone-fill text-primary"></i>{" "}
                    {localSelectedPartner?.phone1 ? (
                      <a href={`tel:${localSelectedPartner.phone1}`} onClick={(e) => e.stopPropagation()}>
                        {localSelectedPartner.phone1}
                      </a>
                    ) : (
                      "-"
                    )}
                    {localSelectedPartner?.phone2 ? ` | ${localSelectedPartner.phone2}` : ""}
                  </div>
                </div>
              </div>

            </div>
          </div>
        </div>
      </div>

      {formik.errors[field?.name] && formik.touched[field?.name] && (
        <div className="text-danger small mt-1">
          {formik.errors[field?.name]}
        </div>
      )}
    </div>
  );
}

export default SelectedBusinessPartnerBox;