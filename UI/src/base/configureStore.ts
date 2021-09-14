import { applyMiddleware, createStore } from 'redux';
import { routerMiddleware } from 'connected-react-router';
import thunkMiddleware from 'redux-thunk';

import rootReducer, { history } from './reducers';

export default function configureStore(preloadedState: any) {
  const definedMiddlewares = [routerMiddleware(history), thunkMiddleware];
  const middlewareEnhancer = applyMiddleware(...definedMiddlewares);
  const store = createStore(rootReducer, preloadedState, middlewareEnhancer);
  return store;
}
