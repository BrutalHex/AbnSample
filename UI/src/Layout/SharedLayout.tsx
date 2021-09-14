import React, { FunctionComponent } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

// eslint-disable-next-line react/prop-types
const SharedLayout: FunctionComponent<any> = ({ children }) => (
  <div className="row">{children}</div>
);

export default SharedLayout;
