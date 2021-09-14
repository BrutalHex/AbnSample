/* eslint-disable no-debugger */
import { connect, ConnectedProps } from 'react-redux';
import { analyticsThunkDispatch } from '../../base/BaseTypes';
import { RootState } from '../../base/reducers';
import analyticsCalculatorPage from './AnalyticsCalculatorPage';
import { SendData } from './AnalyticsCalculatorPageAction';
import analyticsCalculator from './AnalyticsCalculator';

const mapStateToProps = (state: RootState) => {
 
  return { state: state };
};

const mapDispatchToProps = (dispatch: analyticsThunkDispatch) => {
  return {
    handleSendClick: (values:any) => {

      dispatch(SendData(values));
    },
  };
};

const connector = connect(mapStateToProps, mapDispatchToProps);

type PropsFromRedux = ConnectedProps<typeof connector>;

export interface analyticsCalculatorPageProps extends PropsFromRedux {
  error: string | null;
  statusResult: analyticsCalculator;
  handleSendClick(values: any): void;
}

const analyticsCalculatorPageContainer = connector(analyticsCalculatorPage);
export default analyticsCalculatorPageContainer;
