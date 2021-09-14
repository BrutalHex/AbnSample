/* eslint-disable camelcase */
import { IGeneralAction } from './IGeneralAction';
import AnalyticsCalculator from '../Pages/AnalyticsCalculator/AnalyticsCalculator';

export const analytics_Status = 'analytics_Status';

export interface IAnalyticsCalculatorAction extends IGeneralAction<typeof analytics_Status, AnalyticsCalculator> {}
