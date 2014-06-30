DynamicExpressProvider(动态表达式计算引擎提供者)
===========================
该类库中用于继承Core类库中的ExpressBuilder，来实现具体的计算，实现类需要实现具体的计算结果方法；
目前该项目中以JS为例子进行了具体实现，其中类文件JSExpressBuilder就是核心类，该类继承了ExpressBuilder并重载了Run方法。

  未来
  ---------------------------
  实现SqliteBuilder类，展示如果继承ExpressBuilder来实现新的扩展。
