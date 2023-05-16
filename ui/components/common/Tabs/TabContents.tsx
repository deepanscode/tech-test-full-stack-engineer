import React from 'react';

interface TabContentsProps {
	id: string,
	children: React.ReactNode;
}

const TabContents: React.FC<TabContentsProps> = ({ id, children }) => {
	return (
		<div id={id} className='w-full'>{children}</div>
	)
};

export default TabContents;