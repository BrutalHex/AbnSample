import { createReducer } from '../../base/reducerUtils';
import { ISpinnerChangeAction } from '../../Types/ISpinnerChangeAction';
/* eslint-disable camelcase */
const spinnerChange = (initstate: boolean, action: ISpinnerChangeAction): boolean => {
  return action.payload;
};

const spinnerReducer = createReducer(false, {
  Spinner_Change: spinnerChange,
});

export default spinnerReducer;
