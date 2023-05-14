'use client'

import 'flowbite';
import Job from './components/Job'
import TabHeaders from './components/common/Tabs/TabHeaders';
import TabHeader from './components/common/Tabs/TabHeader';
import TabContents from './components/common/Tabs/TabContents';
import TabContent from './components/common/Tabs/TabContent';


export default function Home() {
	return (
		<main className="flex min-h-screen flex-col items-center p-24  bg-gray-50 dark:bg-gray-800">
			<TabHeaders target='leadsTabContent'>
				<TabHeader id="invited-tab" target='invited'>
					Invited
				</TabHeader>
				<TabHeader id="accepted-tab" target='accepted'>
					Accepted
				</TabHeader>
			</TabHeaders>
			<TabContents id='leadsTabContent'>
				<TabContent id="invited" source='invited-tab'>
					<Job/>
					<Job/>
					<Job/>
				</TabContent>
				<TabContent id="accepted" source='accepted-tab'>
					<Job/>
				</TabContent>
				</TabContents>
		</main>
	)
}
