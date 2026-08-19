const yup = require('yup');
const { optionalNumber } = require('../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  header: yup.object({
    id: optionalNumber(),
    make: optionalNumber(),
    model: optionalNumber(),
    grade: optionalNumber(),
    colour: optionalNumber(),
    year: optionalNumber(),
    engineCapacity: optionalNumber(),
    fuelType: optionalNumber(),
    transmission: optionalNumber(),
    millage: optionalNumber(),
    chassisNo: yup.string().nullable(),
    supplier: yup.string().nullable(),
    customer: yup.string().nullable(),
    purchaseDate: yup.string().nullable(),
    cifYen: optionalNumber(),
    auctionPrice: optionalNumber(),
    tax: optionalNumber(),
    freight: optionalNumber(),
    paymentDate: yup.string().nullable(),
    paymentAmount: optionalNumber(),
    paymentRate: optionalNumber(),
    paymentAmountYen: optionalNumber(),
    paymentDetails: yup.string().nullable(),
    lcOpenDetailsBank: yup.string().nullable(),
    JPY: optionalNumber(),
    lcOpenDetailsDate: yup.string().nullable(),
    lcMarginAmount: optionalNumber(),
    lcMarginDate: yup.string().nullable(),
    lcSettlementAmount: optionalNumber(),
    lcSettlementCharges: optionalNumber(),
    lcSettlementDate: yup.string().nullable(),
    dutyAmount: optionalNumber(),
    dutyDate: yup.string().nullable(),
    clearingCharges: optionalNumber(),
    clearingDate: yup.string().nullable(),
    salesTax: optionalNumber(),
    transportCost: optionalNumber(),
    totalCost: optionalNumber(),
    description: yup.string().nullable(),
  }).required(),
});

const deleteSchema = yup.object({
  id: yup.number().required(),
});

const uploadSchema = yup.object({
  id: yup.number().required(),
});

module.exports = { updateSchema, deleteSchema, uploadSchema };
