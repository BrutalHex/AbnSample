import { combineReducers } from 'redux';
import { createBrowserHistory } from 'history';
import { connectRouter } from 'connected-react-router';
import analyticsCalculatorReducer  from '../Pages/AnalyticsCalculator/AnalyticsCalculatorPageReducer';
import spinnerReducer from '../components/Spinner/spinnerReducer';
import AnalyticsCalculator from '../Pages/AnalyticsCalculator/AnalyticsCalculator';
import { ActoinTypes } from '../Types/ActionTypes';
import { ActionType } from 'typesafe-actions';



export const history = createBrowserHistory();

export type Act = ActionType<ActoinTypes>;

export type RootState = {
  status: AnalyticsCalculator,
  pending: boolean,
  router: ReturnType<typeof connectRouter>
};

const rootReducer = combineReducers<RootState, Act>({
  status: analyticsCalculatorReducer as any,
  pending: spinnerReducer as any,
  router: connectRouter(history) as any,
});

export default rootReducer;
