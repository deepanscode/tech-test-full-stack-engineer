import { useState } from "react";
import { useJobs } from "@/hooks";
import { JobStatus } from "@/enums";
import NewJob from "@/components/job/new_jobs/NewJob";
import InfiniteScroll from 'react-infinite-scroll-component';

export default function AcceptedJobsLayout() {
    const [status] = useState<JobStatus>(JobStatus.new);

    const {
        data,
        fetchNextPage,
        hasNextPage,
        isLoading,
        isError,
        error
    } = useJobs(10, status);

    if (isLoading) {
        return <div className="info-text">Loading...</div>;
    }

    if (isError && error) {
        return <div className="info-text">Error: Something went wrong!</div>;
    }

    return (
        <InfiniteScroll
            dataLength={data ? data.pages.reduce((acc, page) => acc + page.jobs.length, 0) : 0}
            next={fetchNextPage}
            hasMore={hasNextPage || false}
            loader={<p className="info-text">Loading...</p>}
            endMessage={<i/>}
        >
            {data &&
                data.pages.map((page) =>
                    page.jobs.map((job) => <NewJob key={job.id} job={job} />)
                )}
        </InfiniteScroll>
    );
}