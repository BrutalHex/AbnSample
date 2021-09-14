import React from 'react';

import {   Route, Redirect, Switch } from 'react-router-dom';

/** Layouts **/
import SharedLayout from './Layout/SharedLayout';
import { DashboardLayoutRoute } from './Layout/DashboardLayout';

import analyticsCalculatorPageContainer from './Pages/AnalyticsCalculator/AnalyticsCalculatorPageContainer';

function App() {
  return (
    <SharedLayout>
      <Switch>
        <Route exact path="/">
          <Redirect to="/analytics" />
        </Route>
        <Route path={['/analytics']}>
          <DashboardLayoutRoute>
            <Switch>
              <Route path="/analytics" component={analyticsCalculatorPageContainer} />
            </Switch>
          </DashboardLayoutRoute>
        </Route>
      </Switch>
    </SharedLayout>
  );
}

export default App;
