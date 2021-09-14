import { IAnalyticsCalculatorAction } from './IAnalyticsCalculatorAction';
import { IGeneralAction } from './IGeneralAction';
import { ISpinnerChangeAction } from './ISpinnerChangeAction';
export function creatAction<TType, TPayload>(
  inputType: TType,
  inputPayload: TPayload
): IGeneralAction<TType, TPayload> {
  const result: IGeneralAction<TType, TPayload> = {
    type: inputType,
    payload: inputPayload,
    error: false,
    meta: null,
  };

  return result;
}

export type ActoinTypes = IAnalyticsCalculatorAction | ISpinnerChangeAction;
