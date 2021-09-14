/* eslint-disable no-debugger */
import React, { FunctionComponent, useState } from 'react';
import * as yup from 'yup';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { Formik } from 'formik';
import SpinnerContainer from '../../components/Spinner/Spinner';
import { analyticsCalculatorPageProps } from './AnalyticsCalculatorPageContainer';
import Setting from '../../base/settings';
import axios from 'axios';


const analyticsCalculatorPage: FunctionComponent<analyticsCalculatorPageProps> = (
  props: analyticsCalculatorPageProps
) => {

  const [cmpVals, setCmpVals] = useState(props.state);

 const [timer,setTimer]=useState(false);

 let handle:any;
 debugger;
      if(props.state.status != null && !timer)
      {
        setTimer(true);
         handle=    setTimeout(() => {
             
            const fetchUrl = `${Setting.getApiUrl('Analytics/GetStatus')}/${props.state.status.Id}`;
            debugger;
    axios({
      method: 'get',
      url: fetchUrl,
    }).then(function (response: any) {      debugger;
      setCmpVals({...cmpVals,status:response.data});
    });
           }, 2000); 

         
        
      }
        if(props.state.status != null && props.state.status.status!==0)
           {
            clearTimeout(handle);
           }



 






  const schema = yup.object({

    Name:yup.string()
    .required("Please enter the Name field")
    .matches(/^[aA-zZ\s]+$/, "Only alphabets are allowed for Name field "),
    Email:yup.string().trim().email('E-mail is not valid!').required('E-mail is required!')


  });

  let statusObjectPreview = [<div key="thisisempty2332">no results</div>];

  if (props.state.status != null && props.state.status) {
    statusObjectPreview = Object.keys(props.state.status).map((property: any, index: number) => {
      return (
        <div className="row" key={`currencyValues_${property}_${index}`}>
          <div className="col-11 rate-vals border-bottom border-bottom-dashed">
            <span className="material-icons">info</span>
            <span className="title badge bg-info">{property}</span>
            <span className="value">{ (props.state.status as any )[property] }</span>
          </div>
        </div>
      );
    });
  }

  return (
    <div className="col-12">
      <SpinnerContainer>
        <div className="row  mt-5">
          <div className="col-12 col-sm-4">
            <Formik
              validationSchema={schema}
              initialValues={{
              Name:'',
              Email:''
              }}
              validate={(values) => {
                const errors = {};
                return errors;
              }}
              onSubmit={(values) => {
             
              
                props.handleSendClick(values );
              }}
            >
              {({ handleSubmit, handleChange, handleBlur, values, isValid, errors }) => (
                <Form
                  noValidate
                  onSubmit={(event: React.FormEvent<HTMLFormElement>): void => {
                    event.preventDefault();
                    handleSubmit(event);
                  }}
                  className=" col-12 col-sm-11 col-md-8"
                >
                  {props.error != null ? (
                    <div className="alert alert-danger" role="alert">
                      {props.error}
                    </div>
                  ) : null}
                  <Form.Group controlId="validationFormikName">
                    <Form.Label>Name</Form.Label>
                    <Form.Control
                      type="text"
                      name="Name"
                      className="form-control form-input"
                      value={values.Name}
                      onChange={handleChange}
                      isInvalid={!!errors.Name}
                    />
                    <Form.Control.Feedback type="invalid">
                      {errors.Name}
                    </Form.Control.Feedback>
                  </Form.Group>
                  <Form.Group controlId="validationFormikEmail">
                    <Form.Label>Email</Form.Label>
                    <Form.Control
                      type="text"
                      name="Email"
                      className="form-control form-input"
                      value={values.Email}
                      onChange={handleChange}
                      isInvalid={!!errors.Email}
                    />
                    <Form.Control.Feedback type="invalid">
                      {errors.Email}
                    </Form.Control.Feedback>
                  </Form.Group>

                  <Button variant="primary" type="submit" className="w-100 mt-1">
                       Start
                  </Button>
                </Form>
              )}
            </Formik>
          </div>
          <div className="col-12 col-sm-6 rate-box">{statusObjectPreview}</div>
        </div>
      </SpinnerContainer>
    </div>
  );
};

export default analyticsCalculatorPage;
