import { memo } from "react";
import { useFormik } from "formik";
import * as Yup from "yup";
import InputField from "../components/InputField";
import SelectedBusinessPartnerBox from "../features/BusinessPartners/select-bp";
import SwitchGroup from "../components/SwitchGroup";

export const useFormikBuilder = (fields, handleInquirySubmit) => {
  //i need to remove undefined fields from the fields object
  // fields = Object.fromEntries(
  //   Object.entries(fields).filter(([key, field]) => field !== undefined),
  // );
  const formik = useFormik({
    initialValues: Object.fromEntries(
      Object.entries(fields).map(([key, field]) => {
        if (field.initialValue !== undefined) return [key, field.initialValue];
        switch (field.type) {
          case 'checkbox':
          case 'switch':
            return [key, false];
          case 'images':
          case 'switch-group':
            return [key, []];
          default:
            return [key, ''];
        }
      }),
    ),
    validationSchema: Yup.object(
      Object.fromEntries(
        Object.entries(fields).map(([key, field]) => [key, field.validation]),
      ),
    ),
    onSubmit: handleInquirySubmit,
  });

  return formik;
};

export const FieldsRenderer = memo(({
  fields,
  formik,
  components = {},
  inputProps = {},
  fieldInputProps = {},
}) => {
  if (!fields) return null;

  return (
    <>
      {Object.keys(fields).map((key) => {
        if (fields[key]?.isVisible === false) return null;

        const field = fields[key];
        const isOptional = !field.validation;
        const mergedInputProps = { ...inputProps, ...(fieldInputProps[key] || {}) };

        if (field?.type === "br") {
          return (
            <div key={key} className="fb-spacer">
              <br />
            </div>
          );
        }

        if (field?.type === "heading") {
          return (
            <div
              key={key}
            // style={{
            //   fontWeight: "bold",
            //   textDecoration: "underline",
            //   marginTop: "10px",
            //   marginBottom: "5px",
            //   width: "100%",
            // }}
            >
              <h1 className="h3 fw-bold text-secondary mb-3 mt-3">
                {field?.label}
              </h1>
            </div>
          );
        }

        if (field?.type === "partner-select") {
          return (
            <SelectedBusinessPartnerBox
              key={field.name || key}
              field={field}
              formik={formik}
              className={field.className}
              required={!isOptional}
            />
          );
        }
        if (field?.type === "switch-group") {
          return (
            <SwitchGroup
              formik={formik}
              key={field.name || key}
              data={field.dataBinding?.data || []}
              onChange={(updatedTags) => {
                formik.setFieldValue(field.name, updatedTags);
                // if (onJobTagChange) {
                //   onJobTagChange(updatedTags);
                // }
              }}
              className={field.className}
              defaultValue={false}
              title={field.placeholder}
              checkedIds={formik.values[field.name]}
            />
          );
        }
        const Custom = components[field?.type];
        if (Custom) {
          return (
            <Custom
              key={field.name || key}
              field={field}
              formik={formik}
              className={field.className}
            />
          );
        }
        return (
          <InputField
            key={field.name || key}
            {...field}
            formik={formik}
            required={!isOptional}
            {...mergedInputProps}
          />
        );
      })}
    </>
  );
});
