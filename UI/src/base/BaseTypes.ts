import { Action } from 'redux';
import { ThunkAction, ThunkDispatch } from 'redux-thunk';
import { RootState } from './reducers';
import { useSelector, TypedUseSelectorHook } from 'react-redux';

type ExtraArg = undefined;

export type analyticsThunkResult<TType> = ThunkAction<TType, RootState, ExtraArg, Action>;

export type analyticsThunkDispatch = ThunkDispatch<RootState, ExtraArg, Action>;

export const useTypedSelector: TypedUseSelectorHook<RootState> = useSelector;

export type NullableNumber = number | null;
