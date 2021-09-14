import { createReducer } from '../../base/reducerUtils';
import { IAnalyticsCalculatorAction } from '../../Types/IAnalyticsCalculatorAction';
import AnalyticsCalculator from './AnalyticsCalculator';

 

const analyticsCalculator = (initstate: AnalyticsCalculator, action: IAnalyticsCalculatorAction): AnalyticsCalculator => {
  return action.payload;
};
const analyticsCalculatorReducer = createReducer(null, {
  analytics_Status: analyticsCalculator,
});
export default analyticsCalculatorReducer;


