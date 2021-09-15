/* eslint-disable no-debugger */
import React, { FunctionComponent, useEffect, useState } from 'react';
import * as yup from 'yup';
import * as signalR from '@microsoft/signalr';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { Formik } from 'formik';
import SpinnerContainer from '../../components/Spinner/Spinner';
import { analyticsCalculatorPageProps } from './AnalyticsCalculatorPageContainer';
import Setting from '../../base/settings';

require('@microsoft/signalr');

const analyticsCalculatorPage: FunctionComponent<analyticsCalculatorPageProps> = (
  props: analyticsCalculatorPageProps
) => {
  let [cmpVals, setCmpVals] = useState(props.state.status);
  if (props.state.status != null && cmpVals == null) {
    cmpVals = props.state.status;
  }
  let [connectionToHost, setConnectionToHost] = useState({} as any);

  useEffect(() => {
    (async function anyNameFunction() {
      if (props.state.status == null) {
        const con = new signalR.HubConnectionBuilder()
          .withUrl(Setting.baseAddress + 'apphub')
          .build();

        con.on('SendMessage', (inputInfo: any) => {
          debugger;

          setCmpVals(inputInfo);
          props.state.status = inputInfo;
        });

        con.keepAliveIntervalInMilliseconds = 1000;

        await con.start().catch(function (err: any) {
          return console.error(err.toString());
        });
        setConnectionToHost(con);
        connectionToHost = con;
      }
    })();
  }, []);

  const schema = yup.object({
    Name: yup
      .string()
      .required('Please enter the Name field')
      .matches(/^[aA-zZ\s]+$/, 'Only alphabets are allowed for Name field '),
    Email: yup.string().trim().email('E-mail is not valid!').required('E-mail is required!'),
  });

  let statusObjectPreview = [<div key="thisisempty2332">no results</div>];

  const previeFields = ['statusText', 'progress', 'result', 'name', 'email'];

  if (cmpVals != null && cmpVals) {
    statusObjectPreview = previeFields.map((property: any, index: number) => {
      return (
        <div className="row" key={`currencyValues_${property}_${index}`}>
          <div className="col-11 rate-vals border-bottom border-bottom-dashed">
            <span className="material-icons">info</span>
            <span className="title badge bg-info">{property}</span>
            <span className="value">{(cmpVals as any)[property]}</span>
          </div>
        </div>
      );
    });
  }

  let buttonItem = <div></div>;
  if (props.state.status == null) {
    buttonItem = (
      <Button variant="primary" type="submit" className="w-100 mt-1">
        Start
      </Button>
    );
  }

  return (
    <div className="col-12">
      <SpinnerContainer>
        <div className="row  mt-5">
          <div className="col-12 col-sm-4">
            <Formik
              validationSchema={schema}
              initialValues={{
                Name: '',
                Email: '',
              }}
              validate={(values) => {
                const errors = {};
                return errors;
              }}
              onSubmit={(values) => {
                props.handleSendClick({
                  ...values,
                  connectionId: connectionToHost.connection.connectionId,
                });
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
                    <Form.Control.Feedback type="invalid">{errors.Name}</Form.Control.Feedback>
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
                    <Form.Control.Feedback type="invalid">{errors.Email}</Form.Control.Feedback>
                  </Form.Group>

                  {buttonItem}
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
