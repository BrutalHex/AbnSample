/* eslint-disable no-debugger */
/* eslint-disable camelcase */
'use strict';

import { Setting } from '../../base/settings';
import { analyticsThunkDispatch, analyticsThunkResult } from '../../base/BaseTypes';
import { creatAction } from '../../Types/ActionTypes';
import { analytics_Status } from '../../Types/IAnalyticsCalculatorAction';
import AnalyticsCalculator from './AnalyticsCalculator';

import { Spinner_Change } from '../../Types/ISpinnerChangeAction';
import axios from 'axios';

export function SendData(values: any): analyticsThunkResult<void> {
  return (dispatch: analyticsThunkDispatch) => {
    dispatch(creatAction(Spinner_Change, true));

    const fetchUrl = `${Setting.getApiUrl('Analytics/StartCalculation')}`;

    axios({
      method: 'POST',
      url: fetchUrl,
      data: values,
    }).then(function (response: any) {
      let result = new AnalyticsCalculator();
      result = response.data;

      dispatch(creatAction(Spinner_Change, false));
      dispatch(creatAction(analytics_Status, result));
    });
  };
}
