import { debounce } from 'lodash-es';
import axios from 'axios';
import React from 'react';
import { useHistory } from 'react-router-dom';

import './style.css';
import Header from '../../components/Header';
import Main from '../../components/Main';
import { INSTITUTES } from '../../utils/api';
import { SUBJECTS } from '../../utils/constants';

const LIST = [
  {
    id: '1',
    name:
      'Автономная некоммерческая организация высшего образования Московский гуманитарно-экономический университет Калужский институт (филиал)'
  }
];

const InstitutesList = ({ headerTitle, type }) => {
  const history = useHistory();
  const [state, setState] = React.useState({
    search: '',
    subjects: []
  });
  const [list, setList] = React.useState([]);

  const fetchData = React.useCallback(
    debounce(async info => {
      const { data } = await axios.get(INSTITUTES, {
        params: {
          directionCode: info.search,
          subjects: info.subjects
        }
      });
      setList(data);
    }, 500),
    []
  );

  const handleCheckboxChange = id => {
    const { subjects } = state;
    if (subjects.includes(id)) {
      setState(prevState => ({
        ...prevState,
        subjects: prevState.subjects.filter(subjectId => subjectId !== id)
      }));
    } else {
      setState(prevState => ({
        ...prevState,
        subjects: [...prevState.subjects, id]
      }));
    }
  };

  const handleSearchInputChange = event => {
    event.persist();
    setState(prevState => ({ ...prevState, search: event.target.value }));
  };

  React.useEffect(() => {
    fetchData(state);
  }, [state]);

  return (
    <>
      <Header>{headerTitle}</Header>
      <Main>
        <div className="institutes-list__main-container">
          <div className="institutes-list__main-list">
            <input
              onChange={handleSearchInputChange}
              value={state.search}
              className="institutes-list__main-search"
              type="text"
              placeholder="Хочу стать (номер направления подготовки)"
            />
            {list.map(institute => (
              <div
                id={institute.id}
                className="institutes-list__main-university"
                onClick={() => history.push(`/institutes/${institute.id}`)}
              >
                {institute.name}
              </div>
            ))}
          </div>
          <div className="institutes-list__main-subjects">
            <div className="institutes-list__main-subjects-header">Я сдаю</div>
            {SUBJECTS.map(subject => (
              <div key={subject.id}>
                {subject.label}
                <input
                  onChange={() => handleCheckboxChange(subject.id)}
                  checked={state.subjects.includes(subject.id)}
                  type="checkbox"
                />
              </div>
            ))}
          </div>
        </div>
      </Main>
    </>
  );
};

export default InstitutesList;
