
import  'react-native' ;
import React from 'react' ;
import SortGodine from '../November/SortiranjeGodina'
import renderer from 'react-test-renderer' ;

let findElement = function (tree, element) {
    let result = undefined;
    for(node in tree.children) {
        if(tree.children[node].props.testID==element) {
            result=true;
        }
    }
return result;
}


it('prosjeci po semestrima', () => {
    let tree  = renderer.create(
        <SortGodine />,
        {
            createNodeMock: (element) => {
              if (element.type === PersistGate) { return element.props.children }
              return null;
           }
        }
    ).toJSON();
        console.warn(tree);
    expect(findElement(tree, 'semestri')).toBeDefined();
})
it('prosjeci po godinama', () => {
    let tree  = renderer.create(
        <SortGodine />,
        {
            createNodeMock: (element) => {
              if (element.type === PersistGate) { return element.props.children }
              return null;
           }
        }
    ).toJSON();
        console.warn(tree);
    expect(findElement(tree, 'godine')).toBeDefined();
    //expect(tree).toMatchSnapshot();
})
