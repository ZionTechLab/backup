import React, { useState, useEffect } from 'react';
import companyService from '../Company/CompanyService';

const InvoiceHeader = ({ isTaxInvoice }) => {
  const [company, setCompany] = useState(null);

  useEffect(() => {
    const fetch = async () => {
      const res = await companyService.getPrint();
      if (res.success && res.data) setCompany(res.data);
    };
    fetch();
  }, []);

  const name = company?.companyName || 'Samanala Enterprises';
  const desc = company?.description || '';
  const addr = [company?.addressLine1, company?.addressLine2, company?.city]
    .filter(Boolean)
    .join(', ');
  const tel = [company?.phoneNumber && `Tel: ${company.phoneNumber}`, company?.tel2 && company.tel2, company?.mobile && company.mobile]
    .filter(Boolean)
    .join(' / ');

  return (
    <header className="text-center">
      <h1>{name}</h1>
      {desc && <p>{desc}</p>}
      {addr && <p>{addr}</p>}
      {tel && <p>{tel}</p>}
      {company?.email && <p>{company.email}</p>}
      <div className="inv-box">{isTaxInvoice ? 'TAX INVOICE' : 'INVOICE'}</div>
    </header>
  );
};

export default InvoiceHeader;
